﻿#Region "Microsoft.VisualBasic::1b127d27b6c317e6b6a6445c42bc9d53, mime\text%html\HTML\CSS\Parser\Enums\CssProperty.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xie (genetics@smrucc.org)
    '       xieguigang (xie.guigang@live.com)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.



    ' /********************************************************************************/

    ' Summaries:

    '     Enum CssProperty
    ' 
    ' 
    '  
    ' 
    ' 
    ' 
    ' 
    ' /********************************************************************************/

#End Region

Imports System.ComponentModel

Namespace HTML.CSS

    ''' <summary>
    ''' Css properties list.
    ''' </summary>
    Public Enum CssProperty As Int32

        ''' <summary>
        ''' font-weight
        ''' </summary>
        <Description("font-weight")> font_weight
        ''' <summary>
        ''' border-radius
        ''' </summary>
        <Description("border-radius")> border_radius
        ''' <summary>
        ''' color-stop
        ''' </summary>
        <Description("color-stop")> color_stop
        ''' <summary>
        ''' alignment-adjust
        ''' </summary>
        <Description("alignment-adjust")> alignment_adjust
        ''' <summary>
        ''' alignment-baseline
        ''' </summary>
        <Description("alignment-baseline")> alignment_baseline
        ''' <summary>
        ''' animation
        ''' </summary>
        <Description("animation")> animation
        ''' <summary>
        ''' animation-delay
        ''' </summary>
        <Description("animation-delay")> animation_delay
        ''' <summary>
        ''' animation-direction
        ''' </summary>
        <Description("animation-direction")> animation_direction
        ''' <summary>
        ''' animation-duration
        ''' </summary>
        <Description("animation-duration")> animation_duration
        ''' <summary>
        ''' animation-iteration-count
        ''' </summary>
        <Description("animation-iteration-count")> animation_iteration_count
        ''' <summary>
        ''' animation-name
        ''' </summary>
        <Description("animation-name")> animation_name
        ''' <summary>
        ''' animation-play-state
        ''' </summary>
        <Description("animation-play-state")> animation_play_state
        ''' <summary>
        ''' animation-timing-function
        ''' </summary>
        <Description("animation-timing-function")> animation_timing_function
        ''' <summary>
        ''' appearance
        ''' </summary>
        <Description("appearance")> appearance
        ''' <summary>
        ''' azimuth
        ''' </summary>
        <Description("azimuth")> azimuth
        ''' <summary>
        ''' backface-visibility
        ''' </summary>
        <Description("backface-visibility")> backface_visibility
        ''' <summary>
        ''' background
        ''' </summary>
        <Description("background")> background
        ''' <summary>
        ''' background-attachment
        ''' </summary>
        <Description("background-attachment")> background_attachment
        ''' <summary>
        ''' background-break
        ''' </summary>
        <Description("background-break")> background_break
        ''' <summary>
        ''' background-clip
        ''' </summary>
        <Description("background-clip")> background_clip
        ''' <summary>
        ''' background-color
        ''' </summary>
        <Description("background-color")> background_color
        ''' <summary>
        ''' background-image
        ''' </summary>
        <Description("background-image")> background_image
        ''' <summary>
        ''' background-origin
        ''' </summary>
        <Description("background-origin")> background_origin
        ''' <summary>
        ''' background-position
        ''' </summary>
        <Description("background-position")> background_position
        ''' <summary>
        ''' background-repeat
        ''' </summary>
        <Description("background-repeat")> background_repeat
        ''' <summary>
        ''' background-size
        ''' </summary>
        <Description("background-size")> background_size
        ''' <summary>
        ''' baseline-shift
        ''' </summary>
        <Description("baseline-shift")> baseline_shift
        ''' <summary>
        ''' binding
        ''' </summary>
        <Description("binding")> binding
        ''' <summary>
        ''' bleed
        ''' </summary>
        <Description("bleed")> bleed
        ''' <summary>
        ''' bookmark-label
        ''' </summary>
        <Description("bookmark-label")> bookmark_label
        ''' <summary>
        ''' bookmark-level
        ''' </summary>
        <Description("bookmark-level")> bookmark_level
        ''' <summary>
        ''' bookmark-state
        ''' </summary>
        <Description("bookmark-state")> bookmark_state
        ''' <summary>
        ''' bookmark-target
        ''' </summary>
        <Description("bookmark-target")> bookmark_target
        ''' <summary>
        ''' border
        ''' </summary>
        <Description("border")> border
        ''' <summary>
        ''' border-bottom
        ''' </summary>
        <Description("border-bottom")> border_bottom
        ''' <summary>
        ''' border-bottom-color
        ''' </summary>
        <Description("border-bottom-color")> border_bottom_color
        ''' <summary>
        ''' border-bottom-left-radius
        ''' </summary>
        <Description("border-bottom-left-radius")> border_bottom_left_radius
        ''' <summary>
        ''' border-bottom-right-radius
        ''' </summary>
        <Description("border-bottom-right-radius")> border_bottom_right_radius
        ''' <summary>
        ''' border-bottom-style
        ''' </summary>
        <Description("border-bottom-style")> border_bottom_style
        ''' <summary>
        ''' border-bottom-width
        ''' </summary>
        <Description("border-bottom-width")> border_bottom_width
        ''' <summary>
        ''' border-collapse
        ''' </summary>
        <Description("border-collapse")> border_collapse
        ''' <summary>
        ''' border-color
        ''' </summary>
        <Description("border-color")> border_color
        ''' <summary>
        ''' border-image
        ''' </summary>
        <Description("border-image")> border_image
        ''' <summary>
        ''' border-image-outset
        ''' </summary>
        <Description("border-image-outset")> border_image_outset
        ''' <summary>
        ''' border-image-repeat
        ''' </summary>
        <Description("border-image-repeat")> border_image_repeat
        ''' <summary>
        ''' border-image-slice
        ''' </summary>
        <Description("border-image-slice")> border_image_slice
        ''' <summary>
        ''' border-image-source
        ''' </summary>
        <Description("border-image-source")> border_image_source
        ''' <summary>
        ''' border-image-width
        ''' </summary>
        <Description("border-image-width")> border_image_width
        ''' <summary>
        ''' border-left
        ''' </summary>
        <Description("border-left")> border_left
        ''' <summary>
        ''' border-left-color
        ''' </summary>
        <Description("border-left-color")> border_left_color
        ''' <summary>
        ''' border-left-style
        ''' </summary>
        <Description("border-left-style")> border_left_style
        ''' <summary>
        ''' border-left-width
        ''' </summary>
        <Description("border-left-width")> border_left_width
        ''' <summary>
        ''' border-right
        ''' </summary>
        <Description("border-right")> border_right
        ''' <summary>
        ''' border-right-color
        ''' </summary>
        <Description("border-right-color")> border_right_color
        ''' <summary>
        ''' border-right-style
        ''' </summary>
        <Description("border-right-style")> border_right_style
        ''' <summary>
        ''' border-right-width
        ''' </summary>
        <Description("border-right-width")> border_right_width
        ''' <summary>
        ''' border-spacing
        ''' </summary>
        <Description("border-spacing")> border_spacing
        ''' <summary>
        ''' border-style
        ''' </summary>
        <Description("border-style")> border_style
        ''' <summary>
        ''' border-top
        ''' </summary>
        <Description("border-top")> border_top
        ''' <summary>
        ''' border-top-color
        ''' </summary>
        <Description("border-top-color")> border_top_color
        ''' <summary>
        ''' border-top-left-radius
        ''' </summary>
        <Description("border-top-left-radius")> border_top_left_radius
        ''' <summary>
        ''' border-top-right-radius
        ''' </summary>
        <Description("border-top-right-radius")> border_top_right_radius
        ''' <summary>
        ''' border-top-style
        ''' </summary>
        <Description("border-top-style")> border_top_style
        ''' <summary>
        ''' border-top-width
        ''' </summary>
        <Description("border-top-width")> border_top_width
        ''' <summary>
        ''' border-width
        ''' </summary>
        <Description("border-width")> border_width
        ''' <summary>
        ''' bottom
        ''' </summary>
        <Description("bottom")> bottom
        ''' <summary>
        ''' box-align
        ''' </summary>
        <Description("box-align")> box_align
        ''' <summary>
        ''' box-decoration-break
        ''' </summary>
        <Description("box-decoration-break")> box_decoration_break
        ''' <summary>
        ''' box-direction
        ''' </summary>
        <Description("box-direction")> box_direction
        ''' <summary>
        ''' box-flex
        ''' </summary>
        <Description("box-flex")> box_flex
        ''' <summary>
        ''' box-flex-group
        ''' </summary>
        <Description("box-flex-group")> box_flex_group
        ''' <summary>
        ''' box-lines
        ''' </summary>
        <Description("box-lines")> box_lines
        ''' <summary>
        ''' box-ordinal-group
        ''' </summary>
        <Description("box-ordinal-group")> box_ordinal_group
        ''' <summary>
        ''' box-orient
        ''' </summary>
        <Description("box-orient")> box_orient
        ''' <summary>
        ''' box-pack
        ''' </summary>
        <Description("box-pack")> box_pack
        ''' <summary>
        ''' box-shadow
        ''' </summary>
        <Description("box-shadow")> box_shadow
        ''' <summary>
        ''' box-sizing
        ''' </summary>
        <Description("box-sizing")> box_sizing
        ''' <summary>
        ''' break-after
        ''' </summary>
        <Description("break-after")> break_after
        ''' <summary>
        ''' break-before
        ''' </summary>
        <Description("break-before")> break_before
        ''' <summary>
        ''' break-inside
        ''' </summary>
        <Description("break-inside")> break_inside
        ''' <summary>
        ''' caption-side
        ''' </summary>
        <Description("caption-side")> caption_side
        ''' <summary>
        ''' clear
        ''' </summary>
        <Description("clear")> clear
        ''' <summary>
        ''' clip
        ''' </summary>
        <Description("clip")> clip
        ''' <summary>
        ''' color
        ''' </summary>
        <Description("color")> color
        ''' <summary>
        ''' color-profile
        ''' </summary>
        <Description("color-profile")> color_profile
        ''' <summary>
        ''' column-count
        ''' </summary>
        <Description("column-count")> column_count
        ''' <summary>
        ''' column-fill
        ''' </summary>
        <Description("column-fill")> column_fill
        ''' <summary>
        ''' column-gap
        ''' </summary>
        <Description("column-gap")> column_gap
        ''' <summary>
        ''' column-rule
        ''' </summary>
        <Description("column-rule")> column_rule
        ''' <summary>
        ''' column-rule-color
        ''' </summary>
        <Description("column-rule-color")> column_rule_color
        ''' <summary>
        ''' column-rule-style
        ''' </summary>
        <Description("column-rule-style")> column_rule_style
        ''' <summary>
        ''' column-rule-width
        ''' </summary>
        <Description("column-rule-width")> column_rule_width
        ''' <summary>
        ''' column-span
        ''' </summary>
        <Description("column-span")> column_span
        ''' <summary>
        ''' column-width
        ''' </summary>
        <Description("column-width")> column_width
        ''' <summary>
        ''' columns
        ''' </summary>
        <Description("columns")> columns
        ''' <summary>
        ''' content
        ''' </summary>
        <Description("content")> content
        ''' <summary>
        ''' counter-increment
        ''' </summary>
        <Description("counter-increment")> counter_increment
        ''' <summary>
        ''' counter-reset
        ''' </summary>
        <Description("counter-reset")> counter_reset
        ''' <summary>
        ''' crop
        ''' </summary>
        <Description("crop")> crop
        ''' <summary>
        ''' cue
        ''' </summary>
        <Description("cue")> cue
        ''' <summary>
        ''' cue-after
        ''' </summary>
        <Description("cue-after")> cue_after
        ''' <summary>
        ''' cue-before
        ''' </summary>
        <Description("cue-before")> cue_before
        ''' <summary>
        ''' cursor
        ''' </summary>
        <Description("cursor")> cursor
        ''' <summary>
        ''' direction
        ''' </summary>
        <Description("direction")> direction
        ''' <summary>
        ''' display
        ''' </summary>
        <Description("display")> display
        ''' <summary>
        ''' dominant-baseline
        ''' </summary>
        <Description("dominant-baseline")> dominant_baseline
        ''' <summary>
        ''' drop-initial-after-adjust
        ''' </summary>
        <Description("drop-initial-after-adjust")> drop_initial_after_adjust
        ''' <summary>
        ''' drop-initial-after-align
        ''' </summary>
        <Description("drop-initial-after-align")> drop_initial_after_align
        ''' <summary>
        ''' drop-initial-before-adjust
        ''' </summary>
        <Description("drop-initial-before-adjust")> drop_initial_before_adjust
        ''' <summary>
        ''' drop-initial-before-align
        ''' </summary>
        <Description("drop-initial-before-align")> drop_initial_before_align
        ''' <summary>
        ''' drop-initial-size
        ''' </summary>
        <Description("drop-initial-size")> drop_initial_size
        ''' <summary>
        ''' drop-initial-value
        ''' </summary>
        <Description("drop-initial-value")> drop_initial_value
        ''' <summary>
        ''' elevation
        ''' </summary>
        <Description("elevation")> elevation
        ''' <summary>
        ''' empty-cells
        ''' </summary>
        <Description("empty-cells")> empty_cells
        ''' <summary>
        ''' filter
        ''' </summary>
        <Description("filter")> filter
        ''' <summary>
        ''' fit
        ''' </summary>
        <Description("fit")> fit
        ''' <summary>
        ''' fit-position
        ''' </summary>
        <Description("fit-position")> fit_position
        ''' <summary>
        ''' float-offset
        ''' </summary>
        <Description("float-offset")> float_offset
        ''' <summary>
        ''' font
        ''' </summary>
        <Description("font")> font
        ''' <summary>
        ''' font-effect
        ''' </summary>
        <Description("font-effect")> font_effect
        ''' <summary>
        ''' font-emphasize
        ''' </summary>
        <Description("font-emphasize")> font_emphasize
        ''' <summary>
        ''' font-family
        ''' </summary>
        <Description("font-family")> font_family
        ''' <summary>
        ''' font-size
        ''' </summary>
        <Description("font-size")> font_size
        ''' <summary>
        ''' font-size-adjust
        ''' </summary>
        <Description("font-size-adjust")> font_size_adjust
        ''' <summary>
        ''' font-stretch
        ''' </summary>
        <Description("font-stretch")> font_stretch
        ''' <summary>
        ''' font-style
        ''' </summary>
        <Description("font-style")> font_style
        ''' <summary>
        ''' font-variant
        ''' </summary>
        <Description("font-variant")> font_variant
        ''' <summary>
        ''' grid-columns
        ''' </summary>
        <Description("grid-columns")> grid_columns
        ''' <summary>
        ''' grid-rows
        ''' </summary>
        <Description("grid-rows")> grid_rows
        ''' <summary>
        ''' hanging-punctuation
        ''' </summary>
        <Description("hanging-punctuation")> hanging_punctuation
        ''' <summary>
        ''' height
        ''' </summary>
        <Description("height")> height
        ''' <summary>
        ''' hyphenate-after
        ''' </summary>
        <Description("hyphenate-after")> hyphenate_after
        ''' <summary>
        ''' hyphenate-before
        ''' </summary>
        <Description("hyphenate-before")> hyphenate_before
        ''' <summary>
        ''' hyphenate-character
        ''' </summary>
        <Description("hyphenate-character")> hyphenate_character
        ''' <summary>
        ''' hyphenate-lines
        ''' </summary>
        <Description("hyphenate-lines")> hyphenate_lines
        ''' <summary>
        ''' hyphenate-resource
        ''' </summary>
        <Description("hyphenate-resource")> hyphenate_resource
        ''' <summary>
        ''' hyphens
        ''' </summary>
        <Description("hyphens")> hyphens
        ''' <summary>
        ''' icon
        ''' </summary>
        <Description("icon")> icon
        ''' <summary>
        ''' image-orientation
        ''' </summary>
        <Description("image-orientation")> image_orientation
        ''' <summary>
        ''' image-rendering
        ''' </summary>
        <Description("image-rendering")> image_rendering
        ''' <summary>
        ''' image-resolution
        ''' </summary>
        <Description("image-resolution")> image_resolution
        ''' <summary>
        ''' inline-box-align
        ''' </summary>
        <Description("inline-box-align")> inline_box_align
        ''' <summary>
        ''' left
        ''' </summary>
        <Description("left")> left
        ''' <summary>
        ''' letter-spacing
        ''' </summary>
        <Description("letter-spacing")> letter_spacing
        ''' <summary>
        ''' line-height
        ''' </summary>
        <Description("line-height")> line_height
        ''' <summary>
        ''' line-stacking
        ''' </summary>
        <Description("line-stacking")> line_stacking
        ''' <summary>
        ''' line-stacking-ruby
        ''' </summary>
        <Description("line-stacking-ruby")> line_stacking_ruby
        ''' <summary>
        ''' line-stacking-shift
        ''' </summary>
        <Description("line-stacking-shift")> line_stacking_shift
        ''' <summary>
        ''' line-stacking-strategy
        ''' </summary>
        <Description("line-stacking-strategy")> line_stacking_strategy
        ''' <summary>
        ''' list-style
        ''' </summary>
        <Description("list-style")> list_style
        ''' <summary>
        ''' list-style-image
        ''' </summary>
        <Description("list-style-image")> list_style_image
        ''' <summary>
        ''' list-style-position
        ''' </summary>
        <Description("list-style-position")> list_style_position
        ''' <summary>
        ''' list-style-type
        ''' </summary>
        <Description("list-style-type")> list_style_type
        ''' <summary>
        ''' margin
        ''' </summary>
        <Description("margin")> margin
        ''' <summary>
        ''' margin-bottom
        ''' </summary>
        <Description("margin-bottom")> margin_bottom
        ''' <summary>
        ''' margin-left
        ''' </summary>
        <Description("margin-left")> margin_left
        ''' <summary>
        ''' margin-right
        ''' </summary>
        <Description("margin-right")> margin_right
        ''' <summary>
        ''' margin-top
        ''' </summary>
        <Description("margin-top")> margin_top
        ''' <summary>
        ''' mark
        ''' </summary>
        <Description("mark")> mark
        ''' <summary>
        ''' mark-after
        ''' </summary>
        <Description("mark-after")> mark_after
        ''' <summary>
        ''' mark-before
        ''' </summary>
        <Description("mark-before")> mark_before
        ''' <summary>
        ''' marker-offset
        ''' </summary>
        <Description("marker-offset")> marker_offset
        ''' <summary>
        ''' marks
        ''' </summary>
        <Description("marks")> marks
        ''' <summary>
        ''' marquee-direction
        ''' </summary>
        <Description("marquee-direction")> marquee_direction
        ''' <summary>
        ''' marquee-play-count
        ''' </summary>
        <Description("marquee-play-count")> marquee_play_count
        ''' <summary>
        ''' marquee-speed
        ''' </summary>
        <Description("marquee-speed")> marquee_speed
        ''' <summary>
        ''' marquee-style
        ''' </summary>
        <Description("marquee-style")> marquee_style
        ''' <summary>
        ''' max-height
        ''' </summary>
        <Description("max-height")> max_height
        ''' <summary>
        ''' max-width
        ''' </summary>
        <Description("max-width")> max_width
        ''' <summary>
        ''' min-height
        ''' </summary>
        <Description("min-height")> min_height
        ''' <summary>
        ''' min-width
        ''' </summary>
        <Description("min-width")> min_width
        ''' <summary>
        ''' move-to
        ''' </summary>
        <Description("move-to")> move_to
        ''' <summary>
        ''' nav-down
        ''' </summary>
        <Description("nav-down")> nav_down
        ''' <summary>
        ''' nav-index
        ''' </summary>
        <Description("nav-index")> nav_index
        ''' <summary>
        ''' nav-left
        ''' </summary>
        <Description("nav-left")> nav_left
        ''' <summary>
        ''' nav-right
        ''' </summary>
        <Description("nav-right")> nav_right
        ''' <summary>
        ''' nav-up
        ''' </summary>
        <Description("nav-up")> nav_up
        ''' <summary>
        ''' opacity
        ''' </summary>
        <Description("opacity")> opacity
        ''' <summary>
        ''' orphans
        ''' </summary>
        <Description("orphans")> orphans
        ''' <summary>
        ''' outline
        ''' </summary>
        <Description("outline")> outline
        ''' <summary>
        ''' outline-color
        ''' </summary>
        <Description("outline-color")> outline_color
        ''' <summary>
        ''' outline-offset
        ''' </summary>
        <Description("outline-offset")> outline_offset
        ''' <summary>
        ''' outline-style
        ''' </summary>
        <Description("outline-style")> outline_style
        ''' <summary>
        ''' outline-width
        ''' </summary>
        <Description("outline-width")> outline_width
        ''' <summary>
        ''' overflow
        ''' </summary>
        <Description("overflow")> overflow
        ''' <summary>
        ''' overflow-style
        ''' </summary>
        <Description("overflow-style")> overflow_style
        ''' <summary>
        ''' overflow-x
        ''' </summary>
        <Description("overflow-x")> overflow_x
        ''' <summary>
        ''' overflow-y
        ''' </summary>
        <Description("overflow-y")> overflow_y
        ''' <summary>
        ''' padding
        ''' </summary>
        <Description("padding")> padding
        ''' <summary>
        ''' padding-bottom
        ''' </summary>
        <Description("padding-bottom")> padding_bottom
        ''' <summary>
        ''' padding-left
        ''' </summary>
        <Description("padding-left")> padding_left
        ''' <summary>
        ''' padding-right
        ''' </summary>
        <Description("padding-right")> padding_right
        ''' <summary>
        ''' padding-top
        ''' </summary>
        <Description("padding-top")> padding_top
        ''' <summary>
        ''' page
        ''' </summary>
        <Description("page")> page
        ''' <summary>
        ''' page-break-after
        ''' </summary>
        <Description("page-break-after")> page_break_after
        ''' <summary>
        ''' page-break-before
        ''' </summary>
        <Description("page-break-before")> page_break_before
        ''' <summary>
        ''' page-break-inside
        ''' </summary>
        <Description("page-break-inside")> page_break_inside
        ''' <summary>
        ''' page-policy
        ''' </summary>
        <Description("page-policy")> page_policy
        ''' <summary>
        ''' pause
        ''' </summary>
        <Description("pause")> pause
        ''' <summary>
        ''' pause-after
        ''' </summary>
        <Description("pause-after")> pause_after
        ''' <summary>
        ''' pause-before
        ''' </summary>
        <Description("pause-before")> pause_before
        ''' <summary>
        ''' perspective
        ''' </summary>
        <Description("perspective")> perspective
        ''' <summary>
        ''' perspective-origin
        ''' </summary>
        <Description("perspective-origin")> perspective_origin
        ''' <summary>
        ''' phonemes
        ''' </summary>
        <Description("phonemes")> phonemes
        ''' <summary>
        ''' pitch
        ''' </summary>
        <Description("pitch")> pitch
        ''' <summary>
        ''' pitch-range
        ''' </summary>
        <Description("pitch-range")> pitch_range
        ''' <summary>
        ''' play-during
        ''' </summary>
        <Description("play-during")> play_during
        ''' <summary>
        ''' position
        ''' </summary>
        <Description("position")> position
        ''' <summary>
        ''' presentation-level
        ''' </summary>
        <Description("presentation-level")> presentation_level
        ''' <summary>
        ''' punctuation-trim
        ''' </summary>
        <Description("punctuation-trim")> punctuation_trim
        ''' <summary>
        ''' quotes
        ''' </summary>
        <Description("quotes")> quotes
        ''' <summary>
        ''' rendering-intent
        ''' </summary>
        <Description("rendering-intent")> rendering_intent
        ''' <summary>
        ''' resize
        ''' </summary>
        <Description("resize")> resize
        ''' <summary>
        ''' rest
        ''' </summary>
        <Description("rest")> rest
        ''' <summary>
        ''' rest-after
        ''' </summary>
        <Description("rest-after")> rest_after
        ''' <summary>
        ''' rest-before
        ''' </summary>
        <Description("rest-before")> rest_before
        ''' <summary>
        ''' richness
        ''' </summary>
        <Description("richness")> richness
        ''' <summary>
        ''' right
        ''' </summary>
        <Description("right")> right
        ''' <summary>
        ''' rotation
        ''' </summary>
        <Description("rotation")> rotation
        ''' <summary>
        ''' rotation-point
        ''' </summary>
        <Description("rotation-point")> rotation_point
        ''' <summary>
        ''' ruby-align
        ''' </summary>
        <Description("ruby-align")> ruby_align
        ''' <summary>
        ''' ruby-overhang
        ''' </summary>
        <Description("ruby-overhang")> ruby_overhang
        ''' <summary>
        ''' ruby-position
        ''' </summary>
        <Description("ruby-position")> ruby_position
        ''' <summary>
        ''' ruby-span
        ''' </summary>
        <Description("ruby-span")> ruby_span
        ''' <summary>
        ''' size
        ''' </summary>
        <Description("size")> size
        ''' <summary>
        ''' speak
        ''' </summary>
        <Description("speak")> speak
        ''' <summary>
        ''' speak-header
        ''' </summary>
        <Description("speak-header")> speak_header
        ''' <summary>
        ''' speak-numeral
        ''' </summary>
        <Description("speak-numeral")> speak_numeral
        ''' <summary>
        ''' speak-punctuation
        ''' </summary>
        <Description("speak-punctuation")> speak_punctuation
        ''' <summary>
        ''' speech-rate
        ''' </summary>
        <Description("speech-rate")> speech_rate
        ''' <summary>
        ''' stress
        ''' </summary>
        <Description("stress")> stress
        ''' <summary>
        ''' string-set
        ''' </summary>
        <Description("string-set")> string_set
        ''' <summary>
        ''' table-layout
        ''' </summary>
        <Description("table-layout")> table_layout
        ''' <summary>
        ''' target
        ''' </summary>
        <Description("target")> target
        ''' <summary>
        ''' target-name
        ''' </summary>
        <Description("target-name")> target_name
        ''' <summary>
        ''' target-new
        ''' </summary>
        <Description("target-new")> target_new
        ''' <summary>
        ''' target-position
        ''' </summary>
        <Description("target-position")> target_position
        ''' <summary>
        ''' text-align
        ''' </summary>
        <Description("text-align")> text_align
        ''' <summary>
        ''' text-align-last
        ''' </summary>
        <Description("text-align-last")> text_align_last
        ''' <summary>
        ''' text-decoration
        ''' </summary>
        <Description("text-decoration")> text_decoration
        ''' <summary>
        ''' text-emphasis
        ''' </summary>
        <Description("text-emphasis")> text_emphasis
        ''' <summary>
        ''' text-height
        ''' </summary>
        <Description("text-height")> text_height
        ''' <summary>
        ''' text-indent
        ''' </summary>
        <Description("text-indent")> text_indent
        ''' <summary>
        ''' text-justify
        ''' </summary>
        <Description("text-justify")> text_justify
        ''' <summary>
        ''' text-outline
        ''' </summary>
        <Description("text-outline")> text_outline
        ''' <summary>
        ''' text-overflow
        ''' </summary>
        <Description("text-overflow")> text_overflow
        ''' <summary>
        ''' text-shadow
        ''' </summary>
        <Description("text-shadow")> text_shadow
        ''' <summary>
        ''' text-transform
        ''' </summary>
        <Description("text-transform")> text_transform
        ''' <summary>
        ''' text-wrap
        ''' </summary>
        <Description("text-wrap")> text_wrap
        ''' <summary>
        ''' top
        ''' </summary>
        <Description("top")> top
        ''' <summary>
        ''' transform
        ''' </summary>
        <Description("transform")> transform
        ''' <summary>
        ''' transform-origin
        ''' </summary>
        <Description("transform-origin")> transform_origin
        ''' <summary>
        ''' transform-style
        ''' </summary>
        <Description("transform-style")> transform_style
        ''' <summary>
        ''' transition
        ''' </summary>
        <Description("transition")> transition
        ''' <summary>
        ''' transition-delay
        ''' </summary>
        <Description("transition-delay")> transition_delay
        ''' <summary>
        ''' transition-duration
        ''' </summary>
        <Description("transition-duration")> transition_duration
        ''' <summary>
        ''' transition-property
        ''' </summary>
        <Description("transition-property")> transition_property
        ''' <summary>
        ''' transition-timing-function
        ''' </summary>
        <Description("transition-timing-function")> transition_timing_function
        ''' <summary>
        ''' unicode-bidi
        ''' </summary>
        <Description("unicode-bidi")> unicode_bidi
        ''' <summary>
        ''' vertical-align
        ''' </summary>
        <Description("vertical-align")> vertical_align
        ''' <summary>
        ''' visibility
        ''' </summary>
        <Description("visibility")> visibility
        ''' <summary>
        ''' voice-balance
        ''' </summary>
        <Description("voice-balance")> voice_balance
        ''' <summary>
        ''' voice-duration
        ''' </summary>
        <Description("voice-duration")> voice_duration
        ''' <summary>
        ''' voice-family
        ''' </summary>
        <Description("voice-family")> voice_family
        ''' <summary>
        ''' voice-pitch
        ''' </summary>
        <Description("voice-pitch")> voice_pitch
        ''' <summary>
        ''' voice-pitch-range
        ''' </summary>
        <Description("voice-pitch-range")> voice_pitch_range
        ''' <summary>
        ''' voice-rate
        ''' </summary>
        <Description("voice-rate")> voice_rate
        ''' <summary>
        ''' voice-stress
        ''' </summary>
        <Description("voice-stress")> voice_stress
        ''' <summary>
        ''' voice-volume
        ''' </summary>
        <Description("voice-volume")> voice_volume
        ''' <summary>
        ''' volume
        ''' </summary>
        <Description("volume")> volume
        ''' <summary>
        ''' white-space
        ''' </summary>
        <Description("white-space")> white_space
        ''' <summary>
        ''' white-space-collapse
        ''' </summary>
        <Description("white-space-collapse")> white_space_collapse
        ''' <summary>
        ''' widows
        ''' </summary>
        <Description("widows")> widows
        ''' <summary>
        ''' width
        ''' </summary>
        <Description("width")> width
        ''' <summary>
        ''' word-break
        ''' </summary>
        <Description("word-break")> word_break
        ''' <summary>
        ''' word-spacing
        ''' </summary>
        <Description("word-spacing")> word_spacing
        ''' <summary>
        ''' word-wrap
        ''' </summary>
        <Description("word-wrap")> word_wrap
        ''' <summary>
        ''' fixed
        ''' </summary>
        <Description("fixed")> fixed
        ''' <summary>
        ''' linear-gradient
        ''' </summary>
        <Description("linear-gradient")> linear_gradient
        ''' <summary>
        ''' color-dodge
        ''' </summary>
        <Description("color-dodge")> color_dodge
        ''' <summary>
        ''' center
        ''' </summary>
        <Description("center")> center
        ''' <summary>
        ''' content-box
        ''' </summary>
        <Description("content-box")> content_box
        ''' <summary>
        ''' -webkit-flex
        ''' </summary>
        <Description("-webkit-flex")> _webkit_flex
        ''' <summary>
        ''' flex
        ''' </summary>
        <Description("flex")> flex
        ''' <summary>
        ''' row-reverse
        ''' </summary>
        <Description("row-reverse")> row_reverse
        ''' <summary>
        ''' space-around
        ''' </summary>
        <Description("space-around")> space_around
        ''' <summary>
        ''' first
        ''' </summary>
        <Description("first")> first
        ''' <summary>
        ''' justify
        ''' </summary>
        <Description("justify")> justify
        ''' <summary>
        ''' inter-word
        ''' </summary>
        <Description("inter-word")> inter_word
        ''' <summary>
        ''' uppercase
        ''' </summary>
        <Description("uppercase")> uppercase
        ''' <summary>
        ''' lowercase
        ''' </summary>
        <Description("lowercase")> lowercase
        ''' <summary>
        ''' capitalize
        ''' </summary>
        <Description("capitalize")> capitalize
        ''' <summary>
        ''' nowrap
        ''' </summary>
        <Description("nowrap")> nowrap
        ''' <summary>
        ''' break-all
        ''' </summary>
        <Description("break-all")> break_all
        ''' <summary>
        ''' break-word
        ''' </summary>
        <Description("break-word")> break_word
        ''' <summary>
        ''' overline
        ''' </summary>
        <Description("overline")> overline
        ''' <summary>
        ''' line-through
        ''' </summary>
        <Description("line-through")> line_through
        ''' <summary>
        ''' wavy
        ''' </summary>
        <Description("wavy")> wavy
        ''' <summary>
        ''' myFirstFont
        ''' </summary>
        <Description("myFirstFont")> myFirstFont
        ''' <summary>
        ''' sensation
        ''' </summary>
        <Description("sensation")> sensation
    End Enum
End Namespace
